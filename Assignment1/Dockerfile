FROM ubuntu:20.04

RUN apt-get update

RUN apt-get -yq install tar wget

RUN wget -O home/bitcoin-core.tar.gz https://bitcoin.org/bin/bitcoin-core-0.21.1/bitcoin-0.21.1-x86_64-linux-gnu.tar.gz

RUN cd home

RUN tar -xvzf home/bitcoin-core.tar.gz -C /home

ENTRYPOINT ["./home/bitcoin-0.21.1/bin/bitcoind","-regtest", "-rpcuser=user", "-rpcpassword=secret", "-rpcbind=0.0.0.0", "-rpcallowip=0.0.0.0/0", "-fallbackfee=0.00005"]
