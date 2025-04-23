# KafkaRedisMicroservice

[![.NET](https://img.shields.io/badge/.NET-8.0-blue?logo=dotnet)](https://dotnet.microsoft.com/)  
[![Kafka](https://img.shields.io/badge/Kafka-Confluent%207.6.1-231F20?logo=apachekafka)](https://www.confluent.io/)  
[![Redis](https://img.shields.io/badge/Redis-7.2--alpine-DC382D?logo=redis)](https://hub.docker.com/_/redis)  
[![Docker](https://img.shields.io/badge/Docker-Compose-blue?logo=docker)](https://www.docker.com/products/docker-desktop)  
[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://opensource.org/licenses/MIT)

A microservices demo built with ASP.NET Core (.NET 8), demonstrating a Kafka producer and consumer with Redis for caching and Docker Compose for orchestration.

---

## 🔗 Repository

**GitHub:** [https://github.com/EbrahimSolomon/KafkaRedisMicroservice](https://github.com/EbrahimSolomon/KafkaRedisMicroservice)

---

## 🚀 Features

- ✅ .NET 8 Web APIs
- ✅ Kafka Producer/Consumer communication
- ✅ Redis caching integration
- ✅ Dockerized environment with Kafka, Zookeeper, Redis
- ✅ Swagger documentation

---

🧱 Architecture

+-------------------+     Kafka Topic     +--------------------+
| Message Producer  |  -----------------> | Message Consumer   |
|  .NET 8 API       |                    |  .NET 8 Worker/API |
+-------------------+                    +--------------------+
                                              |
                                              v
                                        +-------------+
                                        |   Redis     |
                                        +-------------+
📦 Prerequisites
.NET 8 SDK

Docker Desktop

Git

🛠️ Getting Started
1. Clone the repository
git clone https://github.com/EbrahimSolomon/KafkaRedisMicroservice.git
cd KafkaRedisMicroservice
2. Run the containers
docker compose build --no-cache
docker compose up -d
3. Access Swagger UIs
Producer API: http://localhost:5000/swagger/index.html

Consumer API: http://localhost:5010/swagger/index.html

🔧 Usage
Producer Endpoint
POST /Message?key=your-key
Content-Type: text/plain
Body: your-message
Consumer Endpoint

GET /Read/your-key

📂 Folder Structure
KafkaRedisMicroservice/
├── MessageProducerService/
│   ├── Controllers/
│   ├── Services/
│   ├── Dockerfile
│   └── Program.cs
│
├── MessageConsumerService/
│   ├── Controllers/
│   ├── Services/
│   ├── Dockerfile
│   └── Program.cs
│
├── docker-compose.yml
└── README.md

🧑‍💻 Author
Developed with ❤️ by Ebrahim Solomon

📃 License
This project is open-source