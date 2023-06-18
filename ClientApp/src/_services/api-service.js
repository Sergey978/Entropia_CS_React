import { fetchWrapper } from "../_helpers";
import config from "../config.json";

const baseUrl = `${config.apiUrl}`;

export const apiService = {
  getCustomtItems,
  getUserStandartItems,
  getSelectUserStandartItems,
  getStandartItems,
  deleteCustomItem,
  deleteStandartItem,
  hideCustomItem,
  hideUserStandartItem,
  addCustomItem,
  addStandartItem,
  modifyUserItems,
  // changeItem,
};

async function getCustomtItems() {
  return fetchWrapper.get(`${baseUrl}/customitem`);
}

async function getStandartItems() {
  return fetchWrapper.get(`${baseUrl}/adminstandartitem`);
}

async function getSelectUserStandartItems() {
  return fetchWrapper.get(`${baseUrl}/userstandartitem/select`);
}

async function getUserStandartItems() {
  return fetchWrapper.get(`${baseUrl}/userstandartitem`);
}

async function addCustomItem(params) {
  return fetchWrapper.post(`${baseUrl}/customitem`, params);
}

async function addStandartItem(params) {
  return fetchWrapper.post(`${baseUrl}/adminstandartitem`, params);
}

async function hideUserStandartItem(id, params) {
  return fetchWrapper.post(`${baseUrl}/userstandartitem/select`, params);
}

async function hideCustomItem(id, params) {
  return fetchWrapper.put(`${baseUrl}/customitem/${id}`, params);
}

async function deleteCustomItem(id) {
  return fetchWrapper.delete(`${baseUrl}/customitem/${id}`);
}

async function deleteStandartItem(id) {
  return fetchWrapper.delete(`${baseUrl}/adminstandartitem/${id}`);
}

async function modifyUserItems(id, params) {
  return fetchWrapper.put(`${baseUrl}/UserCommonItem/${id}`, params);
}

// posting form data to api
async function postForm(apiUrl, data) {
  fetch(`${this.baseUrl}${apiUrl}`, {
    method: "POST",
    headers: {
      "Content-Type": "application/json;charset=utf-8",
    },
    body: JSON.stringify(data),
  })
    .then((response) => {
      // HTTP 301 response
      if (response.redirected) {
        window.location.replace(response.url);
      }
    })
    .catch((error) => console.error(error));
}

async function isUserNameExist(name) {
  let res = this.getResource("/account/isUserNameExist/", `username=${name}`);
  return res;
}

async function isUserEmailExist(email) {
  let res = this.getResource("/account/isUserEmailExist/", `email=${email}`);
  return res;
}

async function addUserCustomItem(params) {
  return fetchWrapper.post(baseUrl, params);
}
