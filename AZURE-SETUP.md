# Azure Deployment - Quick Start Guide

## Option A: Deploy via Azure Portal (Easiest - No CLI needed)

### Step 1: Create Azure Account
1. Go to https://portal.azure.com
2. Sign up for free (gets $200 credit + free services for 12 months)

### Step 2: Create App Service
1. In Azure Portal, click **"Create a resource"**
2. Search for **"Web App"** and click Create
3. Fill in the form:
   - **Subscription**: Your subscription
   - **Resource Group**: Click "Create new" → Name it `EventEaseRG`
   - **Name**: `eventease-app` (or any unique name) - This becomes your URL
   - **Publish**: Code
   - **Runtime stack**: .NET 9 (STS)
   - **Operating System**: Windows
   - **Region**: Choose closest to you (e.g., East US)
   
4. **Pricing Plan**:
   - Click "Change size"
   - Select **Dev/Test** tab
   - Choose **F1 (Free)** - Free tier!
   - Click Apply

5. Click **"Review + create"** → **"Create"**
   - Wait 1-2 minutes for deployment

### Step 3: Connect to GitHub
1. Once created, go to your new App Service
2. In left menu, find **"Deployment Center"**
3. Click **"Settings"** tab
4. Source: Select **"GitHub"**
5. Click **"Authorize"** and sign in to GitHub
6. Configure:
   - Organization: `AltayCoskun`
   - Repository: `EventEase`
   - Branch: `master`
7. Click **"Save"** at the top

### Step 4: Wait for Deployment
- Azure will automatically:
  - Pull your code from GitHub
  - Build it
  - Deploy it
- This takes 5-10 minutes
- Go to **"Deployment Center"** → **"Logs"** to watch progress

### Step 5: Visit Your Website!
- Your URL will be: `https://eventease-app.azurewebsites.net`
  (Replace `eventease-app` with whatever name you chose)
- Click **"Browse"** button at top of App Service page

## Option B: Deploy via Azure CLI (For Advanced Users)

### Prerequisites
- Install Azure CLI: https://aka.ms/installazurecli

### Commands
```powershell
# Login to Azure
az login

# Create resource group
az group create --name EventEaseRG --location eastus

# Create app service plan (free tier)
az appservice plan create --name EventEasePlan --resource-group EventEaseRG --sku F1

# Create web app
az webapp create --name eventease-app --resource-group EventEaseRG --plan EventEasePlan --runtime "DOTNET:9.0"

# Configure GitHub deployment
az webapp deployment source config --name eventease-app --resource-group EventEaseRG --repo-url https://github.com/AltayCoskun/EventEase --branch master --manual-integration

# Get the URL
az webapp show --name eventease-app --resource-group EventEaseRG --query defaultHostName --output tsv
```

## Automatic Updates
Once connected to GitHub:
- Every time you push to `master` branch
- Azure automatically rebuilds and redeploys
- No manual steps needed!

## Troubleshooting

### Check Deployment Status
1. Go to your App Service in Azure Portal
2. Click **"Deployment Center"** → **"Logs"**
3. See build and deployment progress

### View Application Logs
1. In App Service, go to **"Log stream"**
2. See real-time logs from your app

### Common Issues
- **Build fails**: Check logs - usually missing dependencies
- **500 error**: Check application settings, ensure .NET 9 runtime
- **Site not loading**: Wait 10 mins after first deployment

## Cost
- **F1 (Free) tier**: $0/month
  - 1 GB disk space
  - 60 CPU minutes/day
  - Perfect for testing/demo

## Your App URLs After Deployment
- **Production**: https://eventease-app.azurewebsites.net
- **Browse Events**: https://eventease-app.azurewebsites.net/events
- **About**: https://eventease-app.azurewebsites.net/about

Need help? Check Azure Portal logs or contact Azure support!
