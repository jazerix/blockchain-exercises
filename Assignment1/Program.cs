using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Assignment1.Requests;
using Assignment1.Response;

namespace Assignment1
{
    class Program
    {
        private static bool HasExited = false;

        static async Task Main(string[] args)
        {
            Console.Write(
                "Welcome to the Torben Nakamoto Blockchain\r\nWhat would you like to do? ");

            while (!HasExited)
            {
                Console.WriteLine("These are your options:\n- [1] Check balance\n- [2] Create new address\n- [3] Send bitcoin\n- [4] Show unspent transactions\n- [5] Quit");
                Console.WriteLine("Pick option:");
                int.TryParse(Console.ReadLine(), out var option);
                if (option == 0)
                {
                    Console.WriteLine("Invalid input.");
                    continue;
                }

                Console.WriteLine(await DoCommand(option));
            }
        }

        public static async Task<string> DoCommand(int commandId) => commandId switch
        {
            1 => await CheckBalance(),
            2 => await GetNewAddress(),
            3 => await SendBitcoin(),
            4 => await ShowUnspentTransactions(),
            5 => Quit(),
            _ => throw new ArgumentOutOfRangeException(nameof(commandId), commandId, null)
        };

        private static string Quit()
        {
            HasExited = true;
            return "Bye bye";
        }

        private static async Task<string> ShowUnspentTransactions()
        {
            var request = new RpcRequest("listunspent");
            Console.Write("Enter wallet name: ");
            var wallet = Console.ReadLine();
            var response = await GetRequest<GetUnspentTransactions>(request, wallet);

            return response.Result.Aggregate(Environment.NewLine,
                (current, result) => current + $"Address {result.Address} contains {result.Amount} BigBoi Coins");
        }

        private static async Task<string> SendBitcoin()
        {
            Console.Write("From which wallet? ");
            var wallet = Console.ReadLine();
            Console.Write("Enter address to send to: ");
            var inputAddress = Console.ReadLine();
            Console.Write("Enter amount of BigBoi Coins to send: ");
            var inputAmount = Convert.ToDecimal(Console.ReadLine());


            var request = new RpcRequest("sendtoaddress", inputAddress, inputAmount, "send the money", "the money is being sent", true);
            await GetRequest<SendBitcoin>(request, wallet);

            return "The coins have been sent :)";
        }

        private static async Task<string> GetNewAddress()
        {
            Console.Write("Which wallet? ");
            var wallet = Console.ReadLine();
            var request = new RpcRequest("getnewaddress");
            var response = await GetRequest<GetNewAddress>(request, wallet);

            return $"New address is: {response.Result}";
        }

        private static async Task<string> CheckBalance()
        {
            Console.Write("Which wallet? ");
            var wallet = Console.ReadLine();
            var request = new RpcRequest("getbalance");
            var response = await GetRequest<GetBalance>(request, wallet);

            return $"Current balance is: {response?.Result}";
        }
        
        private static async Task<string> GenerateOneBlock()
        {
            var request = new RpcRequest("generate", 1);
            var response = await GetRequest<GetBalance>(request);

            return $"Current balance is: {response?.Result}";
        }

        private static async Task<T> GetRequest<T>(RpcRequest request, string wallet = null)
        {
            using var httpClient = new HttpClient();
            using var message = new HttpRequestMessage(new HttpMethod("POST"),
                $"http://localhost:18443/" + (wallet == null ? "" : $"wallet/{wallet}"));
            var base64Authorization = Convert.ToBase64String(Encoding.ASCII.GetBytes("user:secret"));
            message.Headers.TryAddWithoutValidation("Authorization", $"Basic {base64Authorization}");

            message.Content = new StringContent(JsonSerializer.Serialize(request));
            var response = await httpClient.SendAsync(message);
            var readAsStringAsync = await response.Content.ReadAsStringAsync();

#if DEBUG
            Console.WriteLine(readAsStringAsync);
#endif

            var jsonResponse = JsonSerializer.Deserialize<T>(readAsStringAsync);

            return jsonResponse;
        }
    }
}