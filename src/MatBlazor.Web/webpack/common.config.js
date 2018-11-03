// webpack plugins
const CommonsChunkPlugin = require('webpack/lib/optimize/CommonsChunkPlugin');

module.exports = {

  entry: {
    'matBlazor': [
      './src/main.js'
    ]
  },

  resolve: {

    extensions: ['.js', '.scss'],

    modules: ['node_modules']

  },

  module: {

    rules: [

      {
        test: /\.js$/,
        exclude: /node_modules/,
        use: [
          'babel-loader',
          // 'eslint-loader'
        ]
      },

      {
        test: /\.json$/,
        loader: 'json'
      },

      {
        test: /\.(jpg|png|gif|eot|svg|ttf|woff|woff2)$/,
        loader: 'file'
      },

      {
        test: /\.(mp4|webm)$/,
        loader: 'url?limit=10000'
      }

    ]

  },

  plugins: [
    new CommonsChunkPlugin({
      name: ['matBlazor'],
      minChunks: Infinity
    })
  ]

};
