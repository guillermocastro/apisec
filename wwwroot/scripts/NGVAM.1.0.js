var baseURL = "";
var api = "/api/";
var config = {
    headers: {
        //"Authorisation": token,
        "Accept": 'application/json',
        "Content-Type": 'application/json',
        "cache-control": 'no-cache',
        "Application": 'Valkian Intelligent Management'
    }
};
angular.module('VAM', [])
    .run(function ($rootScope, $window, $document) {
        $rootScope.company = "V&A";
        $rootScope.product = "VCentre Management";
        $rootScope.author = "Guillermo Castro";
        $rootScope.version = "V 1.0.0";
        $rootScope.UserName = $window.localStorage.getItem("UserName");
        $rootScope.tokenKey = $window.localStorage.getItem("tokenKey");
        if ($rootScope.UserName !== "") {
            $rootScope.logonstatus = 'connected';
        } else {
            $rootScope.logonstatus = null;
        }
        $rootScope.Messages = [];
        $rootScope.menus = [
            { "link": "/", "label": "Home" },
            { "link": "/help", "label": "API" },
            { "link": "/home/Accounting", "label": "Accounting" }
        ]
        $rootScope.Rows = 10;
    })
    .controller("Authentication", function ($rootScope, $scope, $document, $window,$http) {
        var apiserver = '';
        var header = {
            "Access-Control-Allow-Headers": "Content-Type",
            "Access-Control-Allow-Methods": "GET, POST, OPTIONS",
            "Access-Control-Allow-Origin": "*" };
        //var tokenstring = " Bearer " + $scope.Token;
        //var config = {
            //"Authorization": tokenstring,
            //"Access-Control-Allow-Origin": "*",
            //"Access-Control-Allow-Methods": "GET,POST,DELETE,PUT",
            //"Access-Control-Allow-Headers": "X-Requested-With,content-type,Authorization"
        //};
        $scope.register = function (Username, Password1, Password2) {
            console.log("register");
            //var parameter = JSON.stringify({
            //    "username": Username,
            //    "Password": Password1,
            //    "ConfirmPassword": Password2
            //});
            //$http.post('/api/Account/Register', parameter)
            $http({
                method: 'POST',
                url: apiserver+'/api/Account/Register',
                contentType: 'application/json; charset=utf-8',
                data: {
                    "Email": Username,
                    "Password": Password1,
                    "ConfirmPassword": Password2
                },
                header:header
            }).then(function (response) {
                console.log("Success");
                $scope.login(UserName, Password);
            }, function (response) {
                console.log("Error");
                console.log(response.data);
            });
        };
        $scope.login = function (Username, Password) {
            console.log("$scope.login");
            var data = {
                "grant_type": 'password',
                "username": Username,
                "password": Password,
            };
            $http({
                method: 'POST',
                url: apiserver+'/Token',
                data: "userName=" + encodeURIComponent(Username) + "&password=" + encodeURIComponent(Password) + "&grant_type=password",
                headers: { 'Content-Type': 'application/x-www-form-urlencoded', "Access-Control-Allow-Origin": "*", "Access-Control-Allow-Methods": "GET, POST, DELETE, PUT, OPTIONS, HEAD" }
            }).then(function (response) {
                console.log("Success");
                var tokenKey = JSON.stringify(response.data.access_token);
                var UserName = JSON.stringify(response.data.userName);
                console.log(response.data);
                $window.localStorage.setItem("tokenKey", tokenKey);
                $window.localStorage.setItem("UserName", UserName);
                $rootScope.UserName = data.userName;
                $rootScope.token = data.access_token;
                $scope.logonstatus = 'connected';
                $rootScope.logonstatus = 'connected';
            }, function (response) {
                console.log("Error");
                console.log(response.data);
            })
        };
        $scope.signoff = function () {
            $window.localStorage.removeItem("tokenKey");
            $window.localStorage.removeItem("UserName");
            $rootScope.logonstatus = null;
            $rootScope.UserName = 'anonymous';
            $scope.UserName = 'anonymous';
            $rootScope.token = '';
        };
    });

angular.module("VAM").controller("VCentre", function ($scope, $rootScope,$http) { 
    $scope.VCentre=[];
    console.log("VCentre"); 
    $scope.GetVCentreAll=function(){
        console.log("$scope.GetVCentreAll");
        var s=baseURL+api+"VCentre";
        console.log(s);
        $http.get(s).then(function(response){
            $scope.VCentre=response.data;
            //console.log(VCentre);
        },function(response){
            console.log("Error");
        })
    };
    $scope.SaveVCentre=function(VMID,NAME,Purpose,Owner,Department,KeyApplications,State,DataImportUTC){
        console.log("Saving data...");
        console.log(purpose);
    };
    console.log("going...");
    $scope.GetVCentreAll();
    console.log($scope.VCentre);

});
angular.module("VAM").controller("HR", function ($scope, $rootScope,$http, API) {
    console.log("Human Resources Management in progress");
    $scope.HoursToDecimal = function (h) {
        var r = "";
        if (h === null) {
            r = h;
        } else {
            r = h.toString();
        }
        return r;
    };
    $scope.DayToJSonTime = function (d) {
        var m = "";
        var s = "";
        var r = "";
        if (d === null) {
            r = null;
        } else {
            h = d.getHours(d);
            console.log(h);
            m = d.getMinutes(d);
            r = r.concat("PT").concat(h).concat("H");
            console.log(r);
            if (m !== 0) {
                r = r.concat(m).concat("M");
                console.log(r);
            }
        }
        console.log(r);
        return r;
    };
    $scope.JSONTimeToTime = function (d) {
        var i = "";
        var j = "";
        var h = "";
        var m = "";
        if (d === null) {
            r = null;
        } else {
            d = d.replace("PT", "");
            d = d.replace("PT", "");
            i = d.indexOf("H");
            j = d.indexOf("M");
            h = d.substring(0, i);
            if (h.length === 1) {
                h = "0".concat(h);
            }
            if (j === -1) {
                m = "00";
            } else {
                m = d.substring(i + 1, j);
                if (m.length === 1) {
                    m = "0".concat(m);
                }
            }
            r = h.concat(":").concat(m);
        }
        return r;
    };
    $scope.postCalendar = function (CalendarName, HoursSun, HoursMon, HoursTue, HoursWed, HoursThu, HoursFri, HoursSat, StartSun, StartMon, StartTue, StartWed, StartThu, StartFri, StartSat, EndSun, EndMon, EndTue, EndWed, EndThu, EndFri, EndSat) {
        console.log("postCalendar");
        console.log({ "CalendarName": CalendarName, "HoursSun": HoursSun, "HoursMon": HoursMon, "HoursTue": HoursTue, "HoursWed": HoursWed, "HoursThu": HoursThu, "HoursFri": HoursFri, "HoursSat": HoursSat, "StartSun": StartSun, "StartMon": StartMon, "StartTue": StartTue, "StartWed": StartWed, "StartThu": StartThu, "StartFri": StartFri, "StartSat": StartSat, "EndSun": EndSun, "EndMon": EndMon, "EndTue": EndTue, "EndWed": EndWed, "EndThu": EndThu, "EndFri": EndFri, "EndSat": EndSat });
        var s = baseURL + api + "Calendars";
        $http.post(s, {
            "CalendarName": CalendarName, "HoursSun": HoursSun, "HoursMon": HoursMon, "HoursTue": HoursTue, "HoursWed": HoursWed, "HoursThu": HoursThu, "HoursFri": HoursFri, "HoursSat": HoursSat, "StartSun": StartSun, "StartMon": StartMon, "StartTue": StartTue, "StartWed": StartWed, "StartThu": StartThu, "StartFri": StartFri, "StartSat": StartSat, "EndSun": EndSun, "EndMon": EndMon, "EndTue": EndTue, "EndWed": EndWed, "EndThu": EndThu, "EndFri": EndFri, "EndSat": EndSat
        }, { "headers": { 'Content-Type': 'application/json' } }).then(function (response) {
            $scope.CalendarId = null;
            $scope.CalendarName = null;
            $scope.HoursSun = null;
            $scope.HoursMon = null;
            $scope.HoursTue = null;
            $scope.HoursWed = null;
            $scope.HoursThu = null;
            $scope.HoursFri = null;
            $scope.HoursSat = null;
            $scope.StartSun = null;
            $scope.StartMon = null;
            $scope.StartTue = null;
            $scope.StartWed = null;
            $scope.StartThu = null;
            $scope.StartFri = null;
            $scope.StartSat = null;
            $scope.EndSun = null;
            $scope.EndMon = null;
            $scope.EndTue = null;
            $scope.EndWed = null;
            $scope.EndThu = null;
            $scope.EndFri = null;
            $scope.EndSat = null;
            $scope.CalendarID = 0;
            $scope.CalendarAdd = false;
            API.GetAPI("Calendars", "Calendars");
        }, function (response) {
            console.log("Error");
            console.log(response.data);
        });
    };
    $scope.deleteCalendar = function (Id) {
        console.log("deleteCalendar");
        var s = baseURL + api + "Calendars" + "('" + Id + "')";
        $http.delete(s).then(function (response) {
            API.GetAPI("Calendars", "Calendars");
        }, function (response) {
            console.log("Error");
            console.log(response.data);
        });
    };
    $scope.putCalendar = function (CalendarId, CalendarName, HoursSun, HoursMon, HoursTue, HoursWed, HoursThu, HoursFri, HoursSat, StartSun, StartMon, StartTue, StartWed, StartThu, StartFri, StartSat, EndSun, EndMon, EndTue, EndWed, EndThu, EndFri, EndSat) {
        console.log("putCalendar");
        var s = baseURL + api + "Calendars" + "('" + CalendarId + "')";
        var m = { "CalendarId": CalendarId, "CalendarName": CalendarName, "HoursSun": HoursSun, "HoursMon": HoursMon, "HoursTue": HoursTue, "HoursWed": HoursWed, "HoursThu": HoursThu, "HoursFri": HoursFri, "HoursSat": HoursSat, "StartSun": StartSun, "StartMon": StartMon, "StartTue": StartTue, "StartWed": StartWed, "StartThu": StartThu, "StartFri": StartFri, "StartSat": StartSat, "EndSun": EndSun, "EndMon": EndMon, "EndTue": EndTue, "EndWed": EndWed, "EndThu": EndThu, "EndFri": EndFri, "EndSat": EndSat };
        console.log(m);
        $http.put(s, m, {
            "content-type": "application/json",
            "cache-control": "no-cache"
        }).then(function (response) {
            $scope.CalendarId = null;
            $scope.CalendarName = null;
            $scope.HoursSun = null;
            $scope.HoursMon = null;
            $scope.HoursTue = null;
            $scope.HoursWed = null;
            $scope.HoursThu = null;
            $scope.HoursFri = null;
            $scope.HoursSat = null;
            $scope.StartSun = null;
            $scope.StartMon = null;
            $scope.StartTue = null;
            $scope.StartWed = null;
            $scope.StartThu = null;
            $scope.StartFri = null;
            $scope.StartSat = null;
            $scope.EndSun = null;
            $scope.EndMon = null;
            $scope.EndTue = null;
            $scope.EndWed = null;
            $scope.EndThu = null;
            $scope.EndFri = null;
            $scope.EndSat = null;
            $scope.CalendarID = 0;
            $scope.CalendarAdd = false;
            API.GetAPI("Calendars", "Calendars");
        }, function (response) {
            console.log("Error");
            console.log(response.data);
        });
    };
    $scope.postResource = function (ResourceName, ResourceType, Units, Initials, Title, Responsible, CalendarId, CostHour, Avatar) {
        console.log("postResource");
        var s = baseURL + api + "Resources";
        $http.post(s, { "ResourceName": ResourceName, "ResourceType": ResourceType, "Units": Units, "Initials": Initials, "Title": Title, "Responsible": Responsible, "CalendarId": CalendarId, "CostHour": CostHour, "Avatar": Avatar }).then(function (response) {
            $scope.ResourceAdd = false;
            $scope.ResourceId = null;
            $scope.ResourceName = null;
            $scope.ResourceType = null;
            $scope.Units = null;
            $scope.Initials = null;
            $scope.Title = null;
            $scope.Responsible = null;
            $scope.CalendarId = null;
            $scope.CostHour = null;
            $scope.Avatar = null;
            API.GetAPI("Resources", "Resources");
        }, function (response) {
            console.log("Error en postResource ")
        });
    };
    $scope.putResource = function (ResourceId, ResourceName, ResourceType, Units, Initials, Title, Responsible, CalendarId, CostHour, Avatar) {
        var s = baseURL + api + "Resources" + "(" + ResourceId + ")";
        var m = { "ResourceId": ResourceId, "ResourceName": ResourceName, "ResourceType": ResourceType, "Units": Units, "Initials": Initials, "Title": Title, "Responsible": Responsible, "CalendarId": CalendarId, "CostHour": CostHour, "Avatar": Avatar };
        $http.put(s, m, { "content-type": "application/json", "cache-control": "no-cache" }).then(function (response) {
            $scope.ResourceId = null;
            $scope.ResourceName = null;
            $scope.ResourceType = null;
            $scope.Units = null;
            $scope.Initials = null;
            $scope.Group = null;
            $scope.Responsible = null;
            $scope.CalendarId = null;
            $scope.CostHour = null;
            $scope.Avatar = null;
            API.GetAPI("Resources", "Resources");
        }, function (response) {
            console.log("Error in putResource")
        })
    };
    $scope.postHourType = function (HourTypeId, HourTypeName) {
        console.log("postHourTypes");
        var s = baseURL + api + "HourTypes";
        $http.post(s, { "HourTypeId": HourTypeId, "HourTypeName": HourTypeName }).then(function (response) {
            $scope.HourTypeId = null;
            $scope.HourTypeName = null;
            API.GetAPI("HourTypes", "HourTypes");
        }, function (response) {
            console.log("Error en postHourTypes")
        });
    };
    $scope.putHourType = function (HourTypeId, HourTypeName) {
        var s = baseURL + api + "HourTypes" + "('" + HourTypeId + "')";
        var m = { "HourTypeId": HourTypeId, "HourTypeName": HourTypeName};
        $http.put(s, m, { "content-type": "application/json", "cache-control": "no-cache" }).then(function (response) {
            $scope.HourTypeId = null;
            $scope.HourTypeName = null;
            API.GetAPI("HourTypes", "HourTypes");
        }, function (response) {
            console.log("Error in putHourType")
        })
    };
    $scope.deleteHourType = function (HourTypeId) {
        console.log("deleteHourType");
        var s = baseURL + api + "HourTypes" + "('" + HourTypeId + "')";
        console.log(s);
        $http.delete(s).then(function (response) {
            API.GetAPI("HourTypes", "HourTypes");
        }, function (response) {
            console.log("Error en deleteHourType");
            console.log(response.data);
        });
    };
});

//javascript:void(0) es lo mismo que "#"