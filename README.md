# StudentManagement API

A .NET 9.0 Web API for managing students.

## Deployment to Render

This project is configured for easy deployment to [Render](https://render.com/).

### Prerequisites

1.  A [Render](https://render.com/) account.
2.  This repository push to GitHub/GitLab.

### Steps

1.  **Log in to Render** and go to your **Dashboard**.
2.  Click **New +** and select **Blueprint**.
3.  Connect your repository.
4.  Render will automatically detect the `render.yaml` file and configure the service for you.
5.  Click **Apply** or **Create Web Service**.

### Configuration

-   **Environment Variables**: The `render.yaml` sets `ASPNETCORE_ENVIRONMENT` to `Production`. You can add more environment variables (e.g., database connection strings) in the Render dashboard under yours service's **Environment** tab.
-   **Port**: The application listens on port `8080` by default. Render detects this automatically.

## Local Development

To run locally with Docker:

```bash
docker build -t student-api .
docker run -p 8080:8080 student-api
```

Access the API at `http://localhost:8080`.
