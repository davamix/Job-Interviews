var restify = require('restify');

function respond(req, res, next){
    res.contentType = 'json';
    //res.send('hello ' + req.params.name);
    console.log("URL: %s\nDate: %s", req.url, req.params.date);
    res.json({
        "Facility": {
            "FacilityId": "eff24e99-ceb1-49d8-b5f5-ce6b6483e8ed",
            "Name": "Las Palmeras",
            "Address": "Plaza de la independencia 36, 38006 Santa Cruz de Tenerife"
        },
        "SlotDurationMinutes": 10,
        "Monday": {
            "WorkPeriod": {
                "StartHour": 9,
                "EndHour": 17,
                "LunchStartHour": 13,
                "LunchEndHour": 14
            }
        },
        "Thursday":{  
            "StartHour":10,
            "EndHour":13,
            "LunchStartHour":17,
            "LunchEndHour":19,
            "BusySlots":[ 
                {
                    "Start":"2017-06-15T10:00:00",
                    "End":"2017-06-15T11:00:00"
                },
                {
                    "Start":"2017-06-15T11:00:00",
                    "End":"2017-06-15T12:00:00"
                },
                {
                    "Start":"2017-06-15T17:00:00",
                    "End":"2017-06-15T18:00:00"
                }
            ]
        },
        "Wednesday": {
            "WorkPeriod": {
                "StartHour": 9,
                "EndHour": 17,
                "LunchStartHour": 13,
                "LunchEndHour": 14
            }
        },
        "Friday": {
            "WorkPeriod": {
                "StartHour": 8,
                "EndHour": 16,
                "LunchStartHour": 13,
                "LunchEndHour": 14
            }
        }
    });
    next();
}

function postRespond(req, res, next){
    console.log(JSON.stringify(req.body));
    res.send(200);
    next();
}

var server = restify.createServer();
server.use(restify.plugins.bodyParser());
///api/availablity/GetAvailability/
server.get('/api/availability/GetAvailability/:date', respond);
//server.head('/api/availability/GetAvailability/:date', respond);

server.post('/api/availability/TakeSlot', postRespond);

server.listen(8080, function(){
    console.log('%s listening at %s', server.name, server.url);
});
