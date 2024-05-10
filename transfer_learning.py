import tensorflow as tf

def personalize_model(model,num_classes,data_X,data_y,patient_id):

    for layer in model.layers:
        layer.trainable = False

    new_layers = [
        tf.keras.layers.Dense(128, activation='relu'),
        tf.keras.layers.Dense(128, activation='relu'),
        tf.keras.layers.Flatten(),
        tf.keras.layers.Dense(num_classes, activation='softmax')
    ]
    new_model = tf.keras.Sequential([
        model,
        *new_layers
    ])

    new_model.compile(optimizer='adam', loss='categorical_crossentropy', metrics=['accuracy'])  

    new_model.fit(x=data_X, y=data_y, epochs=5, batch_size=32)
    new_model.save("model_{patient_id}.keras")


##############

# import pickle

# with open('dataX.pkl', 'rb') as file:
#     X = pickle.load(file)
# with open('datay.pkl', 'rb') as file:
#     y = pickle.load(file)

############

# mlp_model = tf.keras.models.load_model("mlp_model.keras")
# personalize_model(mlp_model,4,X[0],y[0],'123')