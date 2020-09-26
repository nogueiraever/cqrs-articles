import axios from "axios";
import { getApiUrl } from "./environment";

let url = "";

const api = axios.create({
  baseURL: url,
});

api.interceptors.request.use(async (config) => {
  if (!url) url = await getApiUrl();
  config.baseURL = url;
  return config;
});

export default api;
