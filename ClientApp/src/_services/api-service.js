export default class ApiService {

  // if api base url same as server host set is empty
  //_apiBase = '';
  //_apiBase = 'http://192.168.1.131:8080';
  //_apiBase = "http://"+window.location.hostname;
  _apiBase = "http://localhost:8080";

  async getResource(url, params) {
    const res = await fetch(`${this._apiBase}${url}`,
      {
        headers: {
          'Content-Type': 'application/x-www-form-urlencoded',
        },
        method: "POST",
        //  body: "param1=value1&param2=value2"
        body: params
      }
    );

    if (!res.ok) {
      throw new Error(`Could not fetch ${url}` +
        `, received ${res.status}`)
    }
    return await res.json();
  }


  // posting form data to api
  postForm(apiUrl, data) {     
    
    fetch(`${this._apiBase}${apiUrl}`,
      {
        
        method: 'POST',
        headers: {
          'Content-Type': 'application/json;charset=utf-8'
        },
        body: JSON.stringify(data)
      })
      .then(response => {
        // HTTP 301 response
        if (response.redirected) {
          window.location.replace(response.url);
        }

      })
      .catch(error => console.error(error));
  }


  async isUserNameExist(name) {
    let res = this.getResource("/account/isUserNameExist/", `username=${name}`);
    return res;
  }

  async isUserEmailExist(email) {

    let res = this.getResource("/account/isUserEmailExist/", `email=${email}`);
    return res;
  }

}