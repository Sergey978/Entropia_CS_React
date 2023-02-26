import { fetchWrapper } from "../_helpers";
import config from "../config.json";

const baseUrl = `${config.apiUrl}`;

export const apiService = {
  getCustomtItems,
  // getStandartItems,
  // deleteCustomItem,
  hideCustomItem,
  // hideStandartItem,
  addCustomItem,
  // changeItem,
};

//  ------------EXAMPLE-------------
// function login(email, password) {
//   return fetchWrapper
//     .post(`${baseUrl}/authenticate`, { email, password })
//     .then((user) => {
//       // publish user to subscribers and start timer to refresh token
//       userSubject.next(user);
//       startRefreshTokenTimer();
//       return user;
//     });
// }

// -------------- EXAMPLE ---------------
// function getById(id) {
//   return fetchWrapper.get(`${baseUrl}/${id}`);
// }

async function getCustomtItems() {
  return fetchWrapper.get(`${baseUrl}/customitem`);
}

async function addCustomItem(params) {
  return fetchWrapper.post(`${baseUrl}/customitem`, params);
}

async function hideCustomItem(id, params) {
  return fetchWrapper.put(`${baseUrl}/customitem/${id}`, params);
}

// async function addCustomItem(params) {
//   const res = await fetch(`${this.baseUrl}` + "/customitem", {
//     headers: {
//       "Content-Type": "application/x-www-form-urlencoded",
//     },
//     method: "POST",
//     //  body: "param1=value1&param2=value2"
//     body: params,
//   });

//   if (!res.ok) {
//     throw new Error(`Could not fetch ${url}` + `, received ${res.status}`);
//   }
//   return await res.json();
// }

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
