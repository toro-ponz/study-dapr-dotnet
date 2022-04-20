# Study Dapr .NET

Based on https://qiita.com/kazumihirose/items/57e3aeaab65a1a68977b.

## Getting started.

```shell
tye run
```

## Tye dashboard

Access to http://localhost:8000.

## Swagger

Access to http://localhost:${port}/swagger each service.
Notice: Port is not fixed, see tye dashboard each run.

## Zipkin

Access to http://localhost:9411.

## RabbitMQ

Run on docker.

```shell
docker run -d --hostname my-rabbit --name some-rabbit -p 5672:5672 -p 5673:5673 -p 15672:15672 rabbitmq:3-management
```

Access to http://localhost:15672.

## mailhog

Run on docker.

```shell
docker run -d -p 8025:8025 -p 1025:1025 mailhog/mailhog
```

Access to http://localhost:8025.
