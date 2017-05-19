# Evaluating Background Process Hosting Options
## Introduction
Here's a hands-on comparison of various options to carry out long running background tasks for distributed enterprise level .Net application.
Following options are evaluated for hosting long running background operations,
* IIS worker process
* Windows Service [WIP]
* Azure Worker Roles [WIP]
* Azure Web Jobs [WIP]
* Azure Functions [WIP]
* Third party libraries like WebBackgrounder, FluentScheduler, Quartz.Net...[more to identify]

### IIS worker process
In your Web application (or Web API) project, host your long running task in a thread under Application_Start event of Global.asax.
Deploy your application in a different application pool within IIS. 
