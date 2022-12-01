# Let's go biking 
## Requirements
### ActiveMQ 5.16.5 
### C# - Servers
- [Newtonsoft Json](https://www.newtonsoft.com/json)
- Tested on .NET Framework 4.8

### Java - Heavy client
- [Maven](https://maven.apache.org)
- [ActiveMQ Client 5.16.5](https://mvnrepository.com/artifact/org.apache.activemq/activemq-client/5.16.5)
- [Cucumber JVM Core 7.9.0](https://mvnrepository.com/artifact/io.cucumber/cucumber-core/7.9.0)
- [JAX WS Maven Plugin 2.6](https://mvnrepository.com/artifact/org.codehaus.mojo/jaxws-maven-plugin/2.6)
- Tested on Java 11

## Configuration
- `JC_DECAUX_API_KEY` parameter in `servers/proxy-cache-server/config.cs` file.
- `OPEN_ROUTE_SERVICE_API_KEY` parameter in `servers/routing-server/config.cs` file.

## Get started
### ActiveMQ version
- Start a activeMQ server `activemq start`
- Copy the activeMQ server address in `ACTIVEMQ_SERVER_URL` in `servers/routing-server/config.cs` file.
- Copy the activeMQ server address in `clients/heavy-soap-client/src/main/java/etu/polytech/Config.java` file.
- Start `proxy-cache-server`
- Start `routing-server`
- Start `heavy-soap-client`
