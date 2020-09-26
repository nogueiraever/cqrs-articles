# LikeButton

This application is a complete solution to a high availability "like button".

# Features!

  - .Net core api
  - CQRS pattern
  - Relational PostgreSQL database to store the articles/likes
  - NoSQL MongoDB database as a read only database, serving as a high availability data access
  - RabbitMQ queues
  - .Net core background service, acting as a like microservice, that only likes a article
  - Reactjs as frontend app, showing the like button that consumes the .Net backend
 
  
# Requirements

 - docker
 - docker compose
 
Alternatively you can install all dependencies manually

 - PostgreSQL
 - MongoDB
 - RabbitMQ
 
# Running
To run this project do you need to follow the steps:
  - clone the project
  - open you command line tool, like bash or powershell
  - run the command on the project root folder: 
```sh
$ docker-compose up
```
The build may take some time, wait for this than access the frontend app: http://localhost
