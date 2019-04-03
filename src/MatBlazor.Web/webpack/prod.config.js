const path = require('path');
const webpackMerge = require('webpack-merge');
const autoprefixer = require('autoprefixer');
const webpackCommon = require('./common.config');

// webpack plugins
const HtmlWebpackPlugin = require('html-webpack-plugin');
const DefinePlugin = require('webpack/lib/DefinePlugin');
const UglifyJsPlugin = require('webpack/lib/optimize/UglifyJsPlugin');
const CopyWebpackPlugin = require('copy-webpack-plugin');
const CleanWebpackPlugin = require('clean-webpack-plugin');
const ExtractTextPlugin = require('extract-text-webpack-plugin');
const LoaderOptionsPlugin = require('webpack/lib/LoaderOptionsPlugin');

module.exports = webpackMerge(webpackCommon, {

  bail: true,

  // devtool: 'source-map',

  output: {

    path: path.resolve(__dirname, '../../MatBlazor/content/dist'),

    filename: '[name].min.js',

    // sourceMapFilename: '[name].map',

    chunkFilename: '[id].js'

  },

  module: {

    rules: [
      {
        test: /\.scss$/,



        use: ExtractTextPlugin.extract({
          fallback: 'style-loader',
          use: [
            {
              loader: 'css-loader',
              options: {
                // modules: true,
                minimize: true,
                sourceMap: false,
                // importLoaders: 2,
                include: [
                  // stylesheets in node_modules and src/styles/global
                  // will be treated as global, i.e. not CSS Modules
                  path.resolve('../node_modules'),
                ],
                localIdentName: '[name]__[local]'
              }
            },
            {
              loader: 'postcss-loader',
              options: {
                config: {
                  path: path.resolve(__dirname, 'postcss.config.js')
                },
                sourceMap: false
              }
            },
            {
              loader: 'sass-loader',
              options: {
                outputStyle: 'expanded',
                sourceMap: false,
                sourceMapContents: false,
                "includePaths": [
                  path.resolve(__dirname, '../node_modules')
                ]
              }
            }
          ]
        })
      }
    ]

  },

  plugins: [
    // new HtmlWebpackPlugin({
    //   inject: true,
    //   template: path.resolve(__dirname, '../static/index.html'),
    //   favicon: path.resolve(__dirname, '../static/favicon.ico'),
    //   minify: {
    //     removeComments: true,
    //     collapseWhitespace: true,
    //     removeRedundantAttributes: true,
    //     useShortDoctype: true,
    //     removeEmptyAttributes: true,
    //     removeStyleLinkTypeAttributes: true,
    //     keepClosingSlash: true,
    //     minifyJS: true,
    //     minifyCSS: true,
    //     minifyURLs: true
    //   }
    // }),
    // new CopyWebpackPlugin([
    //   {from: path.resolve(__dirname, '../static')}
    // ], {
    //   ignore: ['index.html', 'favicon.ico']
    // }),
    new CleanWebpackPlugin(['dist'], {
      root: path.resolve(__dirname, '..'),
      exclude: '.gitignore'
    }),
    new DefinePlugin({
      'process.env': {
        NODE_ENV: '"production"'
      }
    }),
    new ExtractTextPlugin('[name].min.css'),
    new UglifyJsPlugin({

      // beautify: true,
      // mangle : false,
      // compress : false,

      compressor: {
        screw_ie8: true,
        warnings: false
      },
      mangle: {
        screw_ie8: true
      },
      output: {
        comments: false,
        screw_ie8: true
      },
      sourceMap: false,

    }),
    new LoaderOptionsPlugin({
      options: {
        context: '/',
        sassLoader: {
          includePaths: [path.resolve(__dirname, '../src')]
        }
      }
    })
  ]

});
