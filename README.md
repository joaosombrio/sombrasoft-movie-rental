# sombrasoft-movie-rental

Requirements to run:
- docker

Instructions:
```bash
git clone https://github.com/joaosombrio/sombrasoft-movie-rental.git
```
```bash
cd sombrasoft-movie-rental
```
```bash
docker-compose up --build
```

## Accessible services
- API Swagger documentation - ```http://localhost:5000/swagger```
- mongo-express dashboard - ```http://localhost:8081/```
  - username: ```sombra``` password: ```sombra123!```
- crud app - ```http://localhost:8080/```

## Notes
- The app seeds data when it inits
- A simple crud was implemented for the movies
- Members and Rental History are read only
- The app includes a member summary report in which the query was made by using mongo aggregate function
