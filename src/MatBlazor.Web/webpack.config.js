const path = require('path');
const MiniCssExtractPlugin = require('mini-css-extract-plugin');
const webpack = require("webpack");

var debugMode = true;


module.exports = {
  mode: debugMode ? 'production' : 'development',

  performance: {
    maxEntrypointSize: 1024 * 1024,
    maxAssetSize: 1024 * 1024
  },
  entry: {
    'matBlazor': [
      './src/main.js',
      './src/main.scss'
    ]
  },
  module: {
    rules: [
      {
        test: /\.tsx?$/,
        use: 'ts-loader',
        exclude: /node_modules/
      },
      {
        test: /\.s[ac]ss$/i,
        use: [
          // Creates `style` nodes from JS strings
          // 'style-loader',
          MiniCssExtractPlugin.loader,
          // Translates CSS into CommonJS
          'css-loader',
          // Compiles Sass to CSS
          'sass-loader'
        ]
      }
    ]
  },
  resolve: {
    extensions: ['.ts', '.tsx', '.js', '.css', '.scss']
  },
  plugins: [
    !debugMode ? new webpack.NormalModuleReplacementPlugin(/\.\/environment\.dev/, './environment.prod') : null,
    new MiniCssExtractPlugin({
      // Options similar to the same options in webpackOptions.output
      // both options are optional
      filename: '[name].css',
      chunkFilename: '[id].css'
    })
  ].filter(i=>i),
  output: {
    filename: 'matBlazor.js',
    path: path.resolve(__dirname, '../MatBlazor/wwwroot/dist')
  }
};
