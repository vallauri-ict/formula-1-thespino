const ResourceResult = new _resource('Results');

ResourceResult.ofRace = function (id) {
  return axios.get(`api/Results/of-race/${id}`);
}