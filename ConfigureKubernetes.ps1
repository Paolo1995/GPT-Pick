$Pick = "YourPick"

$DockerfileContent = @"
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build-env
WORKDIR /app

COPY *.csproj ./
RUN dotnet restore

COPY . ./
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:7.0
WORKDIR /app
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "$Pick.dll"]
"@

$DeploymentContent = @"
apiVersion: apps/v1
kind: Deployment
metadata:
  name: $Pick
spec:
  replicas: 1
  selector:
    matchLabels:
      app: $Pick
  template:
    metadata:
      labels:
        app: $Pick
    spec:
      containers:
      - name: $Pick
        image: $Pick
        ports:
        - containerPort: 80
---
apiVersion: v1
kind: Service
metadata:
  name: $Pick
spec:
  selector:
    app: $Pick
  ports:
    - protocol: TCP
      port: 80
      targetPort: 80
  type: LoadBalancer
"@

Set-Content -Path "Dockerfile" -Value $DockerfileContent
Set-Content -Path "deployment.yaml" -Value $DeploymentContent