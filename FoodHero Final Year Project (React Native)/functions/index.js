const functions = require('firebase-functions');
var fetch = require("node-fetch")

const admin = require("firebase-admin")
admin.initializeApp(functions.config().firebase);

//detect when an entry is made, send all notifications to user that has subscribed with the push notification that a new node is added.

exports.sendPushNotification = functions.database.ref('foodDistributor/{id}')
.onCreate(event => { 
    
    const root = event.data.ref.root
    var messages = []

    //return the main promise
    return root.child('/users').once('value').then(snapshot => {

        snapshot.forEach(childSnapshot => {

            var expoToken = childSnapshot.val().expoToken

            if (expoToken){

                message.push({
                    "to": expoToken,
                    "body": "The food you accepted is going to be expired soon. Please throw it away!"
                })
            }
        })
        return Promise.all(messages)

    }).then(messages => {

        fetch('https://exp.host/--/api/v2/push/send',{

            method:"POST",
            headers: {
                "Accept":"application/json",
                "Content-Type":"application/json"
            },
            body: JSON.stringify(messages)
        })

        return null
    })
})