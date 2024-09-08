### Description

A basic socket software developed in C# to connect a server with the client on a local network using *loopback* or by entering the IP address to exchange messages through an interface.

## Installation

### Server-GUI

1. Clone the repository.
2. Navigation to the Server-GUI.
3. Run command: dotnet build -c Release
4. Run command: dotnet publish -c Release -o ./out
5. Navigation to the directory */out* created.
6. Run command: dotnet Server-GUI.dll
7. Click on *listen*.
8. Await client connection.

### Cliente-GUI

1. Clone the repository.
2. Navigation to the Cliente-GUI.
3. Run command: dotnet build -c Release
4. Run command: dotnet publish -c Release -o ./out
5. Navigation to the directory */out* created.
6. Run command: dotnet Cliente-GUI.dll
7. Check on the terminal the machine IP where Server-GUI is running.
  - Linux: ip addr
  - Windows: ipconfig
8. Enter IP in the input and click *connect*.
9. Start chat with server.

Attention: To leave correcty click on *Disconnect* at the Client-GUI.
