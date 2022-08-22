<img src="https://cdn.cdnlogo.com/logos/a/29/aws-sqs.svg" width="250">

# AWS SQS Demo Implementation

AWS SQS (Simple Queue Service) is a fully managed messaging queue service by 
AWS (Amazone Web Services) for decoupled distributed systems and serverless applications.
Being highly scalable and fully managed, you don't need to care about installing your
own OS and configuring the server. It does it all for you so that you can focus on your
development.

Using SQS with a .NET project was a little challenging for me as it receives all kinds of
 messages and delivers them as a plain string to subscribers. To manage your backend elegantly 
 ensuring minimal impact on the existing system (which was a WebAPI project) I decided to 
 instantiate handler objects based on the model types of the received messages. I'm keeping it 
 open source for anyone and everyone who might find it to be helpful.

 A star to this project would be much appreciated if this project really helped you! 🥰🥰🥰

 
## Tech Stack

**Publisher:** ASP.NET Core Web API application (.NET 6)

**Subscriber:** ASP.NET Core Empty Web Application (.NET 6)
