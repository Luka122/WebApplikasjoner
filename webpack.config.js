const path = require('path');

module.exports = {
  entry: './src/index.js', // Entry point for your React code
  output: {
    path: path.resolve(__dirname, 'wwwroot/js'), // Output directory where Webpack will place the bundled file
    filename: 'bundle.js',
  },
  module: {
    rules: [
      {
        test: /\.(js|jsx)$/,
        exclude: /node_modules/,
        use: {
          loader: 'babel-loader',
        },
      },
    ],
  },
  resolve: {
    extensions: ['.js', '.jsx'],
  },
};
