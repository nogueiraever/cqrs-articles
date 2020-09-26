import axios from "axios";

const getApiUrl = () =>
  axios
    .get("../../configurations/environmentVariables.json")
    .then((response) => {
      return response.data.API_URL;
    });
export { getApiUrl };
