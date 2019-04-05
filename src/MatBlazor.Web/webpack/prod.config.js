var path = require("path");
const UglifyJsPlugin = require('webpack/lib/optimize/UglifyJsPlugin');

module.exports = {
  entry: "./src/main.js",
  output: {
    filename: "matBlazor.js",
    path: path.resolve(__dirname, '../../MatBlazor/content/dist'),
  },

  module: {
    rules: [
      {
        test: /\.js$/,
        use: {
          loader: "babel-loader",
          options: {

          }
        }
      },
      {
        test: /\.scss$/,
        use: [
          {
            loader: "style-loader" // creates style nodes from JS strings
          },
          {
            loader: "css-loader" // translates CSS into CommonJS
          },
          {
            loader: "sass-loader", // compiles Sass to CSS
            options: {
              "includePaths": [
                path.resolve(__dirname, '../node_modules')
              ]
            }
          }
        ]
      }
    ]
  },

  plugins: [
    new UglifyJsPlugin({})
  ],
};
