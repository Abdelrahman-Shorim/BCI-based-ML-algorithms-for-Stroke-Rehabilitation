from flask import Flask, request, jsonify
import numpy as np
import tensorflow as tf

app = Flask(__name__)

mlp_model = tf.keras.models.load_model("mlp_model_3.keras")

@app.route("/predict", methods=["POST"])
def predict():

    input_data = request.json["data"]   
    X = np.array([input_data])
    print(X)
    predictions = mlp_model.predict(X)
    labels = ['right', 'left', 'other', 'other']
    
    predicted_index = np.argmax(predictions)
    
    predicted_label = labels[predicted_index]
    
    return jsonify({"prediction": predicted_label})

if __name__ == "__main__":
    app.run(debug=True)
