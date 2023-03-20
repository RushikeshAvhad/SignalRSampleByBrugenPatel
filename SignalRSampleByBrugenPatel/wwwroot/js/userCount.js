
//  Create Connection
var connectionUserCount = new signalR.HubConnectionBuilder().withUrl("/hubs/userCount").build();

//  Connect to methods that hub invokes aka receive notifications from hub
connectionUserCount.on("updateTotalViews", (value) => {
    var newCountSpan = document.getElementById("totalViewsCounter");
    newCountSpan.innerText = value.toString();
});

//  Invoke hub methods aka send notification to hub
function newWindowLoadedOnClient() {
    connectionUserCount.send("NewWindowLoaded");
}

//  Start Connection
function fulfilled() {
    //  do something on start
    console.log("Connection to User Hub Successful");
}

function rejected() {
    //  Rejected logs
}

connectionUserCount.start().then(fulfilled, rejected);