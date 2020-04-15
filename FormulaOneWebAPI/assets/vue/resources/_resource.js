const _resource = function (uri, apiUri = '/api') {
  this.apiUri = apiUri;
  this.uri = uri;

  this.list = function () {
    return axios.get(`${this.apiUri}/${this.uri}`);
  }

  this.get = function (id) {
    return axios.get(`${this.apiUri}/${this.uri}/${id}`);
  }

  this.store = function (data) {
    return axios.post(`${this.apiUri}/${this.uri}`, data);
  }

  this.update = function (id, data) {
    return axios.put(`${this.apiUri}/${this.uri}/${id}`, data);
  }

  this.destroy = function (id) {
    return axios.delete(`${this.apiUri}/${this.uri}/${id}`);
  }
}