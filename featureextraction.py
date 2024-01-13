import numpy as np
import mne
from mne.decoding import CSP
from mne.filter import filter_data
from sklearn.preprocessing import StandardScaler
from sklearn.svm import SVC
from sklearn.metrics import accuracy_score
from sklearn.model_selection import train_test_split

def FBCSP(X, y, raw):
    # Normalize the data
    scaler = StandardScaler()
    X_normalized = scaler.fit_transform(X.reshape(-1, X.shape[-1])).reshape(X.shape)
    
    # Filter bank decomposition 
    freq_bands = [(8, 12), (12, 16), (16, 20), (20, 24), (24, 30)]
    filtered_data_train = [filter_data(X_normalized, sfreq=raw.info['sfreq'], l_freq=fmin, h_freq=fmax)[0] for fmin, fmax in freq_bands]

    # Combine data
    filtered = np.concatenate(filtered_data_train, axis=-1)

    # Apply CSP on the data
    csp = CSP(n_components=8, reg=0.01, log=True, norm_trace=True)
    new_feature = csp.fit_transform(filtered, y)
    
    return new_feature

def CommonSpatialPattern(X, y):
    # Normalize the data
    scaler = StandardScaler()
    X_normalized = scaler.fit_transform(X.reshape(-1, X.shape[-1])).reshape(X.shape)
    
    # Apply CSP on the training data
    csp = CSP(n_components=8, reg=0.01, log=True, norm_trace=True)
    new_feature = csp.fit_transform(X_normalized, y)
    
    return new_feature