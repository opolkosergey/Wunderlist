angular.module("wunderlistApp", ["ngResource", "ngRoute"])
.constant("listsUrl", "/api/list/")
.constant("itemsUrl", "/api/item/")
.constant("userUrl", "/api/user/")
.constant("userProfileUrl", "/Profile/GetProfile/");