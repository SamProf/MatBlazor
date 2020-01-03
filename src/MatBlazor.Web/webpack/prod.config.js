var path = require("path");
const UglifyJsPlugin = require('uglifyjs-webpack-plugin');
var ProgressPlugin = require('webpack/lib/ProgressPlugin');

module.exports = {

  // stats: 'verbose',


  entry: "./src/main.js",
  // optimization: {
  //   minimize: false
  // },
  output: {
    filename: "matBlazor.js",
    // path: path.resolve(__dirname, '../dist'),
    path: path.resolve(__dirname, '../../MatBlazor/wwwroot/dist'),
  },


  resolve: {
    extensions: [".ts", ".tsx", ".js", ".css", ".scss"]
  },




  module: {
    rules: [
      {
        test: /\.tsx?$/,
        use: 'ts-loader',
        exclude: /node_modules/,
      },
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
      new UglifyJsPlugin({
          parallel: true,
          uglifyOptions: {
              compress: {},
              mangle: true,
              output: {
                  comments: false,
                  beautify: false
              }
          }
    }),
  ],
};
