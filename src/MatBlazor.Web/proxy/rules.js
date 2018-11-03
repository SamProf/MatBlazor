module.exports = {
  '/node-0': {
    target: 'https://api.github.com',
    secure: true,
    headers: {
      'Host': 'api.github.com',
      'Cookie': '' // send cookie on demand
    },
    pathRewrite: function (path) {
      return path.replace(/^\/node-0/, ''); // remove '/node-0' prefix when requesting
    }
  },
  '/node-1': {
    target: 'https://registry.npmjs.org',
    secure: true,
    headers: {
      'Host': 'registry.npmjs.org',
      'Cookie': '' // send cookie on demand
    },
    pathRewrite: function (path) {
      return path.replace(/^\/node-1/, ''); // remove '/node-1' prefix when requesting
    }
  }
};
