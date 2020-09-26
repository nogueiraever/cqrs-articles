FROM node:carbon-alpine as build-deps
WORKDIR /usr/src/app
COPY src/frontend/package.json ./
RUN npm install
COPY /src/frontend/ .
RUN npm run build

FROM nginx:1.17-alpine
RUN ["ls"]
COPY --from=build-deps /usr/src/app/build /usr/share/nginx/html
EXPOSE 80

## startup.sh script is launched at container run
ADD src/frontend/configurations/startup.sh /startup.sh
RUN dos2unix "/startup.sh"
RUN ["chmod", "+x", "/startup.sh"]
CMD /startup.sh


