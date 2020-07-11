# auth-api-netcore

----

 _JSON Web Token (JWT) is an open standard (RFC 7519) that defines a compact and self-contained way for securely transmitting information between parties as a JSON object. This information can be verified and trusted because it is digitally signed. JWTs can be signed using a secret (with the HMAC algorithm) or a public/private key pair using RSA or ECDSA.._


## API Information
### REGISTER

* **URL**

  api/auth/register

* **Method:**
 

   | `POST` |   


* **Data Params**
`{
	"Email": "diaz.nicolasandres@gmail.com",
	"Password": "Nicolas9123!",
	"ConfirmPassword" : "Nicolas9123!"
}`

* **Success Response:**   

  * **Code:** 200 <br />
    **Content:** 
    `{
    "message": "User created succesfully!",
    "isSucces": true,
    "expireDate": null,
    "errors": null
}`
 
* **Error Response:** 

  * **Code:** 400 Bad Request <br />
    **Content:** `{
    "type": "https://tools.ietf.org/html/rfc7231#section-6.5.1",
    "title": "One or more validation errors occurred.",
    "status": 400,
    "traceId": "|6ec792c6-4859c9b1d43eb494.",
    "errors": {
        "$.Password": [
            "The JSON object contains a trailing comma at the end which is not supported in this mode. Change the reader options. Path: $.Password | LineNumber: 4 | BytePositionInLine: 0."
        ]
    }
}`

* **Sample Call:**


```javascript
 var user = {
	"Email": "diaz.nicolasandres@gmail.com",
	"Password": "Nicolas9123!",
	"ConfirmPassword" : "Nicolas9123!"
  }
   $.ajax({
       type: "POST",
       url: "/api/auth/register",
       dataType: "json",
       success: function (msg) {
           console.log(msg)
       },
       data: user
   });  

```

----

### LOGIN - Retrieves JWT TOKEN

* **URL**

  api/auth/login

* **Method:** 

   | `POST` |   


* **Data Params**
`{
	"Email": "diaz.nicolasandres@gmail.com",
	"Password": "Nicolas9123!",
}`

* **Success Response:**   

  * **Code:** 200 <br />
    **Content:** 
    `{
    "message": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJFbWFpbCI6ImRpYXoubmljb2xhc2FuZHJlc0BnbWFpbC5jb20iLCJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1laWRlbnRpZmllciI6IjQ3OThhNTUwLTZiM2YtNDhkYS1iNzE2LTE2ODhkNWVmOGZlNyIsImV4cCI6MTU5NzA5Nzk0NSwiaXNzIjoiaHR0cDovL2RpYXpuaWNvbGFzYW5kcmVzLmNvbSIsImF1ZCI6Imh0dHA6Ly9kaWF6bmljb2xhc2FuZHJlcy5jb20ifQ.FKeXoLuTPY4a_WayMjjVgLOzfec2P_ZUAVPo9XEdtq0",
    "isSucces": true,
    "expireDate": "2020-08-10T22:19:05Z",
    "errors": null
}`
 
* **Error Response:** 

  * **Code:** 400 Bad Request <br />
    **Content:** ```{
    "type": "https://tools.ietf.org/html/rfc7231#section-6.5.1",
    "title": "One or more validation errors occurred.",
    "status": 400,
    "traceId": "|6ec792cb-4859c9b1d43eb494.",
    "errors": {
        "Password": [
            "The field Password must be a string with a minimum length of 5 and a maximum length of 50."
        ]
    }
}```
* **Sample Call:**


```javascript
 var user = {
	"Email": "diaz.nicolasandres@gmail.com",
	"Password": "Nicolas9123!",	
  }
   $.ajax({
       type: "POST",
       url: "/api/auth/login",
       dataType: "json",
       success: function (msg) {
           console.log(msg)
       },
       data: user
   }); 
 
```

