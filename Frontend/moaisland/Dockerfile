FROM node:16.16.0 as build-stage
WORKDIR /var/jenkins_home/workspace/moaisland/Frontend/moaisland
COPY package*.json ./
RUN npm install
COPY . .
RUN npm run build
FROM nginx:stable-alpine as production-stage

COPY --from=build-stage /var/jenkins_home/workspace/moaisland/Frontend/moaisland /usr/share/nginx/html
COPY --from=build-stage /var/jenkins_home/workspace/moaisland/Frontend/moaisland/deploy_conf/nginx.conf /etc/nginx/conf.d/default.conf

EXPOSE 80
CMD ["nginx", "-g", "daemon off;"]