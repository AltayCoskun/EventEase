# EventEase Deployment Guide

## Deploy to Azure App Service (Free)

### Prerequisites
- Azure account (free tier available)
- Azure CLI or use Azure Portal

### Deploy via Azure Portal
1. Go to [Azure Portal](https://portal.azure.com)
2. Create new **App Service**
   - Runtime: .NET 9
   - OS: Windows or Linux
   - Pricing: Free (F1) tier
3. In App Service, go to **Deployment Center**
4. Select **GitHub** as source
5. Authorize and select:
   - Organization: AltayCoskun
   - Repository: EventEase
   - Branch: master
6. Azure will automatically build and deploy

### Deploy via Azure CLI
```bash
# Login to Azure
az login

# Create resource group
az group create --name EventEaseRG --location eastus

# Create app service plan (free tier)
az appservice plan create --name EventEasePlan --resource-group EventEaseRG --sku F1

# Create web app
az webapp create --name eventease-app --resource-group EventEaseRG --plan EventEasePlan --runtime "DOTNET:9.0"

# Deploy from GitHub
az webapp deployment source config --name eventease-app --resource-group EventEaseRG --repo-url https://github.com/AltayCoskun/EventEase --branch master --manual-integration
```

Your app will be available at: `https://eventease-app.azurewebsites.net`

## Alternative: Deploy to Other Platforms

### Render.com (Free)
1. Sign up at [render.com](https://render.com)
2. Click **New +** → **Web Service**
3. Connect GitHub repo
4. Settings:
   - Build Command: `dotnet publish -c Release -o out`
   - Start Command: `dotnet out/EventEase.dll`

### Railway.app (Free tier)
1. Sign up at [railway.app](https://railway.app)
2. New Project → Deploy from GitHub
3. Select EventEase repository
4. Railway auto-detects .NET and deploys

### Fly.io (Free tier)
```bash
# Install flyctl
# Then in your project directory:
fly launch
fly deploy
```
