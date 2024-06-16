# CATBOT
This webapi app is able to connect to you facebook page and
read the contents of your conversations.
When a keyword is hit (in this example "maciatko") a cat is being
sent to a recipient from https://cataas.com/.

The tool is able to handle multiple users asynchronously

## How to set it up

Register yout page in https://developers.facebook.com/
and get the following: 
1. Recipient ids
2. Page id
3. Page auth token

Enter those values in CatBotService.cs, recipients are comma separated string of IDs

Info about where and how to get the needed IDs
https://developers.facebook.com/docs/graph-api/get-started/
