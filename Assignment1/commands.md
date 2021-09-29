`docker compose exec bitcoind /home/bitcoin-0.21.1/bin/bitcoin-cli -regtest -rpcuser=user -rpcpassword=secret createwallet assignment1`

`docker compose exec bitcoind /home/bitcoin-0.21.1/bin/bitcoin-cli -regtest -rpcwallet=assignment1 -rpcuser=user -rpcpassword=secret -generate 101`