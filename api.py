from flask import Flask, request, jsonify
import tensorflow as tf

app = Flask(__name__)

mlp_model = tf.keras.models.load_model("mlp_model.keras")

@app.route("/predict", methods=["POST"])
def predict():
    input_data = request.json["data"]
        
    predictions = mlp_model.predict(X)
    
    predictions_json = jsonify(predictions.tolist())
    
    return predictions_json

if __name__ == "__main__":
    app.run(debug=True)
