echo "Setting the environment variables"
echo "API_URL = ${API_URL}"
echo "TRACKING_ID = ${TRACKING_ID}"
envsubst < "/usr/share/nginx/html/configurations/environmentVariables-template.json" > "/usr/share/nginx/html/configurations/environmentVariables.json"
nginx -g 'daemon off;'
