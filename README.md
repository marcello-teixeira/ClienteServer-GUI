## Description

A socket software developed in C# to connect a server with the client on a local network using *loopback* or by entering the IP address to exchange messages through an interface.

## How work

1. Clone the repository.
2. Navigation to the directory.
3. Begin running Server-GUI
4. Click on "Start Listen"
5. Get the IP Address on the box message.
6. Begin running Client-GUI.
7. Enter IP address in input field.
8. Click "Connect" and start chating.

## Manual Installation 

### Server-GUI

1. Clone the repository.
2. Navigation to the Server-GUI.
3. Run command: dotnet build -c Release
4. Run command: dotnet publish -c Release -o ./out
5. Navigation to the directory */out* created.
6. Run command: dotnet Server-GUI.dll
7. Click on *start listen*.
8. A box message along with the IP address will be shown.
9. Await client connection.

### Cliente-GUI

1. Clone the repository.
2. Navigation to the Cliente-GUI.
3. Run command: dotnet build -c Release
4. Run command: dotnet publish -c Release -o ./out
5. Navigation to the directory */out* created.
6. Run command: dotnet Cliente-GUI.dll
7. Get the IP address on the box message displayed. You can too get IP on the terminal where the Server-GUI is running.
  - Linux: ip addr
  - Windows: ipconfig
8. Enter IP in the input field and click *connect*.
9. Start chat with server.
