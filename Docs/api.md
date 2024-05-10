# IForgor API

- [IForgor API](#iforgor-api)
    - [Auth](#auth)
        - [Register](#register)
            - [Register Request](#register-request)
            - [Register Response](#register-response)
        - [Login](#login)
            - [Login Request](#login-request)
            - [Login Response](#login-response)

## Auth

### Register

```js
POST {{host}}/auth/register
```

#### Register Request

```json
{
    "nickname": "Coriast",
    "email": "someemail@gmail.com",
    "password": "Pass546!"
}
```

#### Register Response

```js
200 OK
```

```json
{
    "id": "b8380e33-e3bb-4ecc-8224-8c143d6190fc",
    "nickname": "Coriast",
    "email": "someemail@gmail.com",
    "token": "ehafD...ahSebzlhE"
}
```

### Login

```js
POST {{host}}/auth/login
```

#### Login Request

```json
{
    "email": "someemail@gmail.com",
    "password": "Pass546!"
}
```

#### Login Response

```js
200 OK
```

```json
{
    "id": "b8380e33-e3bb-4ecc-8224-8c143d6190fc",
    "nickname": "Coriast",
    "email": "someemail@gmail.com",
    "token": "ehafD...ahSebzlhE"
}
```