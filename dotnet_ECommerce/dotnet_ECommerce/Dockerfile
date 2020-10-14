#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443
ARG ADMIN_EMAIL_ARG
ARG APPLICATION_OLIVE_ARG
ARG AUTH_NET_ID_ARG
ARG AUTH_NET_KEY_ARG
ARG PRODUCT_JADE_ARG
ARG SENDGRID_ARG
ENV ADMIN_EMAIL=$ADMIN_EMAIL_ARG
ENV APPLICATION_OLIVE=$APPLICATION_OLIVE_ARG
ENV AUTH_NET_ID=$AUTH_NET_ID_ARG
ENV AUTH_NET_KEY=$AUTH_NET_KEY_ARG
ENV PRODUCT_JADE=$PRODUCT_JADE_ARG
ENV SENDGRID=$SENDGRID_ARG

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build
WORKDIR /src
COPY ["dotnet_ECommerce.csproj", "./"]
RUN dotnet restore "./dotnet_ECommerce.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "dotnet_ECommerce.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "dotnet_ECommerce.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
CMD ASPNETCORE_URLS=http://*:$PORT dotnet dotnet_ECommerce.dll
