# Versioning using Custom Request Header
- Accept-version: v1

## API Header
# After login and have a token, request header
  ```json
    {
      accept-version: v1
      authorization: bearer {json-web-token}
    }
  ```

## APIs Listing
# Authentication API
- Login: POST /api/users/login
  - request header:
    ```json
      {
        "userName": "string",
        "password": "string"
      }
    ```
  - response:
    ```json
    {
    "accessToken": "string",
    "tokenType": "jwt",
    "userId" : 10,
    "userName": "string",
    "perms": 
      [
        {
          "allows": "string",
          "resources": "string"
        }
      ]
    }
  ```
- Logout: PUT /api/users/{userId}/logout

# Customer API
- Get a customer by id: GET /api/customers/{id}
  - request body:
  - response:
    ```json
    {
    "firstName": "string",
    "lastName": "string",
    "email": "string",
    "password": "string",
    "confirmPassword": "string",
    "countryId": "string"
     }
     ```
- Get a all customers: GET /api/customers
- Get a customer by email: GET /api/customers/email/{email}
- Get a customer by purchases: GET /api/customers/purchases
- Add a customer: POST /api/customers
- Update a customer by id: PATCH /api/customers/{id}
- Delete a customer by id: DELETE /api/customers/{id}

# Products API
- Get a product by id: GET /api/products/{id}
  - response:
  ```json
    {
     "code": "string",
     "name": "string",
     "quantity": 10
     }
  ```
- Get all products: GET /api/products
  - response:
    [
      {
        "code": "string",
        "name": "string",
        "quantity": 10
      }
    ]
- Add a product: POST /api/products
  - request body:
  ```json
    {
     "code": "string",
     "name": "string",
     "quantity": 10
    }
  ```
- Update a product by id: PATCH /api/products/{id}
- Delete a product by id: DELETE /api/products/{id}

# Carts API
- Get a cart by customer id: GET /api/carts/customerId/{id}
- Add a cart: POST /api/carts
  - request body:
    - request body: 
    ```json
      {
        "customerId": "id",
        "productId": "id",
        "quantity: 10
      }
    ```
- Add a checkout by customer: POST /api/checkout/customers/{customerId}
- Delete a cart: DELETE /api/carts
  - request body: 
  ```json
    {
      "customerId": "id",
      "productId": "id"
    }
  ```
  
  
## APIs Status code:
- 1xx: redirection
- 2xx: success
  - 200: success default
  - 201: created
  - 202: accepted
  - 204: no content
- 3xx: redirection
  - 301: moved permanently
  - 304: not modified
  
- 4xx: client error
  - 400: bad request
  - 401: unauthorized
  - 403: forbidden
  - 404: not found
  - 405: method not allowed
  - 415: unsupported media type
  
- 5xx: server error
  - 500: internal server error
  - 501: not implemented
