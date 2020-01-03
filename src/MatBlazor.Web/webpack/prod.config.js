var path = require("path");
const UglifyJsPlugin = require('uglifyjs-webpack-plugin');
const MiniCssExtractPlugin = require('mini-css-extract-plugin');


module.exports = {
  entry: {
    'matBlazor': [
      './src/main.js',
      './src/main.scss'
    ]
  },
  // optimization: {
  //   minimize: false
  // },
  output: {
    filename: "matBlazor.js",
    // path: path.resolve(__dirname, '../dist'),
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
          MiniCssExtractPlugin.loader,
          {
            loader: "css-loader" // translates CSS into CommonJS
          },
          {
            loader: "sass-loader", // compiles Sass to CSS
            options: {
              sassOptions: {
                includePaths: [path.resolve(__dirname, '../node_modules')]
              }
            }
          }
        ]
      }
    ]
  },

  plugins: [
    new MiniCssExtractPlugin({
      filename: 'matBlazor.css',
      path: path.resolve(__dirname, '../../MatBlazor/content/dist')
    }),
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
