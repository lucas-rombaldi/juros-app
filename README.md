# JurosApp

<p align="center">
<img src="https://github.com/lucas-rombaldi/juros-app/blob/master/docs/images/base-image.png?raw=true" height="180" width="180"/>
</p>

This is a simple application that provides some services to get taxes and calculate compound interests.
This application is made in a microservice architecture, where the Tax Provider API is totally independant from the Calculation API, even they're in the same solution for now.

## CI

![Build/Test](https://github.com/lucas-rombaldi/juros-app/workflows/Build%20and%20test/badge.svg)

## Release Notes

### 1.0.0

This is the first version of the application, bringing the following features:

- API to get the taxes used for calculation.
- API to calculate the final value based on interest taxes, period and base value.
- API to get this repository URL.

### Next Versions

As every first version, it has many mapped features, like:

- Configure `docker-compose` to run all the API's provided by the application.
- Add more automated unit tests.
- Add some integration tests between the API's.
- Integrate repository URL search with the GitHub API.
- Configure CD workflow and make improvements in CI workflow to ensure code quality.

## Get Started!

All the API's provided by JurosApp are being handled by Swagger/OpenAPI, so you just need to select all the API's in the solution to start and explore it as you wish.
