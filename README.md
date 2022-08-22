# AWS SQS Demo Implementation

AWS SQS (Simple Queue Service) is a fully managed messaging que service by 
AWS (Amazone Web Services) for decoupled distributed systems and server less applications.
It's highly scalable and being fully managed, you don't need to care about installing your
own OS and configuring the server. It does it all for you so that you can focus on your
development.

Using SQS with a .NET project was a little challanging to me as it recieves all kinds of
 messages delivers it as a plain string to subscriber. To manage your backend elegantly 
 ensuring minimal impact to existing system (which was a WebAPI project) I decided to 
 instantiate handler objects based on model types of the recieved messages. I'm keeping it 
 opensource for anyone and everyone who might find it to be helpful.

 A star to this project would be much appriciated if this project really helped you! 🥰🥰🥰

 
## Tech Stack

**Publisher:** ASP.NET Core Web API application (.NET 6)

**Subscriber:** ASP.NET Core Empty Web Application (.NET 6)


![AWS SQS Logo](https://cdn.cdnlogo.com/logos/a/29/aws-sqs.svg)