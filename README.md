# Neo4j.Driver.Logging
A collection of Loggers to use with Neo4j.Driver


## Example of the output from the `ConsoleLogger`

```
DEBUG: Updating routing table for database 'neo4j'.
DEBUG: [conn-<yourServer>:7687-1] Trust is established, resuming connection.
DEBUG: [conn-<yourServer>:7687-1] ~~ [CONNECT] neo4j://<yourServer>:7687/
DEBUG: [conn-<yourServer>:7687-1] C: [HANDSHAKE] 60 60 B0 17 00 02 03 04 00 00 01 04 00 00 00 04 00 00 00 03
DEBUG: [conn-<yourServer>:7687-1] S: [HANDSHAKE] 4.3
DEBUG: [conn-<yourServer>:7687-1] C: HELLO [{scheme, basic}, {principal, neo4j}, {credentials, ******}, {user_agent, neo4j-dotnet/4.3}, {routing, [{address, <yourServer>:7687}]}]
TRACE: [conn-<yourServer>:7687-1] C: 00 88 B1 01 A5 86 73 63 68 65 6D 65 85 62 61 73 69 63 89 70 72 69 6E 63 69 70 61 6C 85 6E 65 6F 34 6A 8B 63 72 65 64 65 6E 74 69 61 6C 73 88 4E 65 6F 34 6A 31 32 33 8A 75 73 65 72 5F 61 67 65 6E 74 D0 10 6E 65 6F 34 6A 2D 64 6F 74 6E 65 74 2F 34 2E 33 87 72 6F 75 74 69 6E 67 A1 87 61 64 64 72 65 73 73 D0 23 63 6F 72 65 31 2E 6E 65 6F 34 6A 63 75 73 74 6F 6D 65 72 73 75 63 63 65 73 73 2E 63 6F 6D 3A 37 36 38 37 00 00
DEBUG: [conn-<yourServer>:7687-1] S: SUCCESS [{server, Neo4j/4.4.0}, {connection_id, bolt-3713}, {hints, []}]
DEBUG: [conn-<yourServer>:7687-1] Connection 'conn-<yourServer>:7687-1' renamed to 'bolt-3713'. The new name identifies the connection uniquely both on the client side and the server side.
DEBUG: [bolt-3713] C: ROUTE { 'address':'<yourServer>:7687' } [] 'neo4j'
TRACE: [bolt-3713] C: 00 37 B3 66 A1 87 61 64 64 72 65 73 73 D0 23 63 6F 72 65 31 2E 6E 65 6F 34 6A 63 75 73 74 6F 6D 65 72 73 75 63 63 65 73 73 2E 63 6F 6D 3A 37 36 38 37 90 85 6E 65 6F 34 6A 00 00
DEBUG: [bolt-3713] S: SUCCESS [{rt, [{servers, [[{addresses, [<yourServer3>:7687]}, {role, WRITE}], [{addresses, [<yourServer2>:7687, <yourServerRR1>:7687, <yourServer>:7687]}, {role, READ}], [{addresses, [<yourServer3>:7687, <yourServer>:7687, <yourServer2>:7687]}, {role, ROUTE}]]}, {ttl, 300}]}]
DEBUG: [bolt-3713] C: RESET
TRACE: [bolt-3713] C: 00 02 B0 0F 00 00
DEBUG: [bolt-3713] S: SUCCESS []
INFO: Routing table is updated => RoutingTable{database=neo4j, routers=[neo4j://<yourServer3>:7687/, neo4j://<yourServer>:7687/, neo4j://<yourServer2>:7687/], writers=[neo4j://<yourServer3>:7687/], readers=[neo4j://<yourServer2>:7687/, neo4j://<yourServerRR1>:7687/, neo4j://<yourServer>:7687/], expiresAfter=300s}
DEBUG: Selected reader for database 'neo4j' with least connected address: 'neo4j://<yourServer2>:7687/' and active connections: 0
DEBUG: [<yourServer2>:7687-2] Trust is established, resuming connection.
DEBUG: [<yourServer2>:7687-2] ~~ [CONNECT] neo4j://<yourServer2>:7687/
DEBUG: [<yourServer2>:7687-2] C: [HANDSHAKE] 60 60 B0 17 00 02 03 04 00 00 01 04 00 00 00 04 00 00 00 03
DEBUG: [<yourServer2>:7687-2] S: [HANDSHAKE] 4.3
DEBUG: [<yourServer2>:7687-2] C: HELLO [{scheme, basic}, {principal, neo4j}, {credentials, ******}, {user_agent, neo4j-dotnet/4.3}, {routing, [{address, <yourServer>:7687}]}]
TRACE: [<yourServer2>:7687-2] C: 00 88 B1 01 A5 86 73 63 68 65 6D 65 85 62 61 73 69 63 89 70 72 69 6E 63 69 70 61 6C 85 6E 65 6F 34 6A 8B 63 72 65 64 65 6E 74 69 61 6C 73 88 4E 65 6F 34 6A 31 32 33 8A 75 73 65 72 5F 61 67 65 6E 74 D0 10 6E 65 6F 34 6A 2D 64 6F 74 6E 65 74 2F 34 2E 33 87 72 6F 75 74 69 6E 67 A1 87 61 64 64 72 65 73 73 D0 23 63 6F 72 65 31 2E 6E 65 6F 34 6A 63 75 73 74 6F 6D 65 72 73 75 63 63 65 73 73 2E 63 6F 6D 3A 37 36 38 37 00 00
DEBUG: [<yourServer2>:7687-2] S: SUCCESS [{server, Neo4j/4.4.0}, {connection_id, bolt-184}, {hints, []}]
DEBUG: [<yourServer2>:7687-2] Connection '<yourServer2>:7687-2' renamed to 'bolt-184'. The new name identifies the connection uniquely both on the client side and the server side.
DEBUG: [bolt-184] C: BEGIN [{mode, r}, {db, neo4j}]
TRACE: [bolt-184] C: 00 13 B1 11 A2 84 6D 6F 64 65 81 72 82 64 62 85 6E 65 6F 34 6A 00 00
DEBUG: [bolt-184] S: SUCCESS []
DEBUG: [bolt-184] C: RUN `MATCH (n) RETURN COUNT(n)`, [] []
DEBUG: [bolt-184] C: PULL [{n, 1000}]
TRACE: [bolt-184] C: 00 1F B3 10 D0 19 4D 41 54 43 48 20 28 6E 29 20 52 45 54 55 52 4E 20 43 4F 55 4E 54 28 6E 29 A0 A0 00 00 00 08 B1 3F A1 81 6E C9 03 E8 00 00
DEBUG: [bolt-184] S: SUCCESS [{t_first, 1}, {fields, [COUNT(n)]}, {qid, 0}]
DEBUG: [bolt-184] S: RECORD [1895157]
DEBUG: [bolt-184] S: SUCCESS [{type, r}, {t_last, 0}, {db, neo4j}]
DEBUG: [bolt-184] C: COMMIT
TRACE: [bolt-184] C: 00 02 B0 12 00 00
DEBUG: [bolt-184] S: SUCCESS [{bookmark, FB:kcwQvMfWMKeQTD2hDQezlWVFpcoABIUTkA==}]
DEBUG: [bolt-184] C: RESET
TRACE: [bolt-184] C: 00 02 B0 0F 00 00
DEBUG: [bolt-184] S: SUCCESS []
```