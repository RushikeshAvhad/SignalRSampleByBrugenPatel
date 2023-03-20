
//  Create Connection
var connectionUserCount = new signalR.HubConnectionBuilder().withUrl("/hubs/userCount").build();

//  Connect to methods that hub invokes aka receive notifications from hub


//  Invoke hub methods aka send notification to hub


//  Start Connection
