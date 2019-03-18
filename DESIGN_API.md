# Versioning using Custom Request Header
- Accept-version: v1

## API Header
# After login and have a token, request header
  ```json
    {
      "accept-version": "v1"
      "authorization": "bearer json-web-token"
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
  - response: 
    ```json
    [
      {
        "firstName": "string",
        "lastName": "string",
        "email": "string",
        "password": "string",
        "confirmPassword": "string",
        "countryId": "string"
      }
    ]
    ```
- Get a customer by email: GET /api/customers/email/{email}
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
- Get a purchases history by customerId: GET /api/customers/{customerId}/purchases
  - response:
    ```json
    {
      "customerId": "string",
      "firstName": "string",
      "lastName": "string",
      "email": "string",
      "totalPurchases": 10,
      "totalProductsPurchased": 10,
      "totalPrice": 100
    }
     ```
- Add a customer: POST /api/customers
  - request: 
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
- Update a customer by id: PATCH /api/customers/{id}
  - request body:
  ```json
  {
    "customerId": "string",
    "firstName": "string",
    "lastName": "string",
    "countryId": "string"
  }
  ```
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
  - request body:
  ```json
    {
    "name": "string",
    "code": "string",
    "quantity": 0,
    "cost": 0
    }
   ```
- Update a product without code: PATCH /api/products/{id}
  - request body:
  ```json
    {
    "name": "string",
    "quantity": 0,
    "cost": 0
    }
   ```
- Delete a product by id: DELETE /api/products/{id}

# Carts API
- Get a cart by customer id: GET /api/carts/customerId/{id}
  - response: 
    ```json
      {
        "customerId": "string",
        "products":
          [
            {
              "code": "string",
              "name": "string",
              "quantity": 10
            }
          ],
        "createdDate": "dateTimeString"
      }
    ```
- Add a cart: POST /api/carts
  - request body:
    ```json
      {
        "customerId": "id",
        "productId": "id",
        "quantity: 10
      }
    ```
- Add a checkout by customer: POST /api/checkout/customers/{customerId}
  - response:
  ```json
    {
      "purchaseId": "guid",
      "totalPrice": 100,
      "checkOutIssue" : ""
    }
  ```
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
