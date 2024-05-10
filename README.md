The demo application simulates interaction between microservices using MongoDB, MassTransit, and RabbitMQ. This allowed me to significantly develop my skills. Note that proper functioning requires appropriate configuration of appsettings.json in the projects.

## Technologies used:
* C#
* .NET
* MongoDB
* DTOS
* Clean Architecture
* DI Injection
* Minimal API (REST)
* JSON
* MassTransit
* RabbitMQ

## How to Use
1. Clone this repository.
2. Before running, proper configuration needs to be done regarding MongoDB, MassTransit, and RabbitMQ in the appsettings.json file and in external sources. Docker was not implemented as my PC is outdated.
3. There are two services that can be run separately. If MassTransit is properly configured, the queue will be used to modify data.
