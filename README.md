# Orange.TestTask.RestQueueService
Сервис работы с очередью сообщений
<!--
*** Thanks for checking out this README Template. If you have a suggestion that would
*** make this better please fork the repo and create a pull request or simple open
*** an issue with the tag "enhancement".
*** Thanks again! Now go create something AMAZING! :D
-->





<!-- PROJECT SHIELDS -->
[![Build Status][build-shield]]()
[![Contributors][contributors-shield]]()
[![MIT License][license-shield]][license-url]



<!-- PROJECT LOGO -->
<br />


  <h3 align="center">README</h3>

  <p align="center">
    README !
    <br />
    <a href="https://github.com/nkiruhin/Orange.TestTask.RestQueueService/blob/master/README.md"><strong>Этот документ »</strong></a>
    <br />
    <br />
    <!--<a href="https://github.com/othneildrew/Best-README-Template">View Demo</a>-->
    ·
    <a href="https://github.com/nkiruhin/Orange.TestTask.RestQueueService/issues">Report Bug</a>
    ·
    <a href="https://github.com/nkiruhin/Orange.TestTask.RestQueueService/issues">Request Feature</a>
  </p>
</p>



<!-- TABLE OF CONTENTS -->
## Table of Contents

* [О проекте](#about)
  * [Технологии](#built-with)
* [Запуск приложения](#getting-started)
  * [Необходимые условия](#prerequisites)
  * [Установка](#installation)
  * [Запуск](#start)
* [Развертывание](#deployment)
* [Использование](#usage)
* [Сопутствующие](#contributing)
* [License](#license)
* [Contact](#contact)



<!-- ABOUT THE PROJECT -->
## About (О проекте)
Проект реализует REST API для отправки и получения простого текстового сообщения через брокер сообщений RebbitMQ.

Реализует паттерн Request-Reply(RPC) (https://www.enterpriseintegrationpatterns.com/patterns/messaging/RequestReply.html)

Для документирования REST API использована OpenAPI Specification (https://swagger.io/specification/)

Поддерживает публикацию в Docker. 

### Built with (Технологии)

* [.Net Core](https://github.com/dotnet/core)


<!-- GETTING STARTED -->
## Getting started (Запуск приложения)

Раздел содержит информацию по разворачиванию сервиса
<p>
Скачайте и установите .NET Core SDK на компьтер.
<p>

### Prerequisites (Необходимые условия)

Необходимые условия для этого проекта вы можете найти по ссылкам
.Net 5

for Windows:
https://docs.microsoft.com/en-us/dotnet/core/install/windows?tabs=net50

for Linux:
https://docs.microsoft.com/en-us/dotnet/core/install/linux

RebbitMQ 

https://www.rabbitmq.com/#getstarted


### Installation (Установка)

1. Клонирование репозитория
```sh
git clone https://github.com/nkiruhin/Orange.TestTask.RestQueueService.git
```


### Start(Запуск)
Предварительно необходимо развернуть брокер сообщений RebbitMQ инструкции по адресу (https://www.rabbitmq.com/#getstarted)

```sh
dotnet restore "src/Orange.TestTask.RestQueueService.Web/Orange.TestTask.RestQueueService.Web.csproj"
```
```sh
dotnet build "src/Orange.TestTask.RestQueueService.Web/Orange.TestTask.RestQueueService.Web.csproj" -c Release -o /app/build
```
```sh
cd /app/build
```
Указать настройки строки подключения к брокеру сообщений в файле appsettings.json.
```sh
dotnet Orange.TestTask.RestQueueService.Web.dll
```

### Deployment(Развертывание)

Запуск в Docker Compose

Предварительно установить Docker Compose (https://docs.docker.com/compose/install/)

Указать настройки строки подключения к брокеру сообщений в файле appsettings.json.

Собрать образ:
```sh
docker-compose build
```
Запустить:
```sh
docker-compose up
```

<!-- USAGE EXAMPLES -->
## Usage (Использование)


Сервис реалзует Post метод /api/SimpleMessage принимающий строку сообщения.

Возращает ответ на принятое сообщение из очереди и время затраченное на пересылку сообщения

<!-- CONTRIBUTING -->
## Contributing

Contributions are what make the open source community such an amazing place to be learn, inspire, and create. Any contributions you make are **greatly appreciated**.

1. Fork the Project
2. Create your Feature Branch (`git checkout -b feature/AmazingFeature`)
3. Commit your Changes (`git commit -m 'Add some AmazingFeature`)
4. Push to the Branch (`git push origin feature/AmazingFeature`)
5. Open a Pull Request



<!-- LICENSE -->
## License

Distributed under the MIT License. See `LICENSE` for more information.



<!-- CONTACT -->
## Contact


Project Link: [https://github.com/nkiruhin/KavkazHub.Remont](https://github.com/nkiruhin/KavkazHub.Remont)









<!-- MARKDOWN LINKS & IMAGES -->
[build-shield]: https://img.shields.io/badge/build-passing-brightgreen.svg?style=flat-square
[contributors-shield]: https://img.shields.io/badge/contributors-1-orange.svg?style=flat-square
[license-shield]: https://img.shields.io/badge/license-MIT-blue.svg?style=flat-square
[license-url]: https://choosealicense.com/licenses/mit
[linkedin-shield]: https://img.shields.io/badge/-LinkedIn-black.svg?style=flat-square&logo=linkedin&colorB=555
[linkedin-url]: https://linkedin.com/in/othneildrew
[product-screenshot]: https://raw.githubusercontent.com/othneildrew/Best-README-Template/master/screenshot.png

