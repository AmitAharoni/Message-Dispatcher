# Message Dispatcher


# Description
A code library that provides its users with a message dispatcher module.  
The main purpose of the dispatcher is to transfer messages indirectly from `sender` users to `receiver` users,  
somewhat like a message broker/ mediator/ pipeline etc.

# Main flow
**1.** A sender puts new messages at the dispatcher, each message is intended for a specific receiver to pull it.  
**2.** The message then waits at the dispatcher until the relevant receiver, pulls it from the dispatcher.  
**3.** A receiver may have multiple messages waiting at the dispatcher.  
**4.** Once a message is pulled by the receiver it is deleted from the dispatcher.  
**5.** A pull request made by a receiver supports the following options for retrieving messages:  
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; i. A specific message.  
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ii. All of his messages.  

# Services
The dispatcher provides two separate sets of services.

## Senders service

- **Put**: puts a new message at the dispatcher. intended for a specific receiver to pull it.
- **Delete**: Deletes a specific message  if it is still waiting at the dispatcher.
- **Is Waiting**: Checks whether a specific message is still waiting at the dispatcher.
- **Listen**: request to be informed by the dispatcher via a dedicated event once a specific message is pulled.

## Receivers service

- **Pull Specific**: Retrieves a specific message that are waiting for that receiver.
- **Pull All**: Retrieves all messages that are waiting for that receiver.

# Persistency
- A persistency provider may be implemented in **any** technique for saving data. 
- The dispatcher may be initialized with a persistency provider, for saving the state of any waiting messages  
as a backup.
- The dispatcher may reload backup during recovery from critical failures.
 

#  Class Diagram

<img src="https://user-images.githubusercontent.com/58184521/120570809-96ecd380-c421-11eb-9669-703a79ba3cb0.png" width="900" /></a>


# Requirements

1.  [Visual Studio Community 2017 15.9.36 (or above).](https://visualstudio.microsoft.com/downloads/)
2.  [.NET Framework 4.6.1 (or above).](https://dotnet.microsoft.com/download) 


# Installation

1. Clone [Message Dispatcher](https://github.com/AmitAharoni/Message-Dispatcher) repository.
   ```sh
   https://github.com/AmitAharoni/Message-Dispatcher.git
   ```
2. Open Visual Studio.
3. Navigate to the project directory.
4. Open the `Message Dispatcher.sln` file. 
5. Start without Debugging (CTRL +  F5).
