import mne
from mne.preprocessing import ICA
import visualization

def pre_processing(raw, l_freq=0.5, h_freq=100, freqs=50, n_components=22, random_state=64, method='picard', event_id=[7, 8, 9, 10], tmin=-0.1, tmax=0.7, baseline=(-0.1, 0), log=None):
    print("Raw Data")
    visualization.plot_raw(raw, duration=3, start=1691.5)
    visualization.plot_psd(raw)

    print("Filtered Data")
    raw_fil = raw.copy().filter(l_freq, h_freq, fir_design='firwin', skip_by_annotation='edge', verbose=log)
    raw_fil = raw_fil.notch_filter(freqs=freqs, verbose=log)
    visualization.plot_raw(raw_fil, duration=3, start=1691.5)
    visualization.plot_psd(raw_fil)

    ica = ICA(n_components=n_components, random_state=random_state, max_iter=800, verbose=log)
    ica.fit(raw_fil, verbose=log)
    ica.plot_components(verbose=log)

    ica.plot_sources(raw_fil)
    eog_indices, eog_scores = ica.find_bads_eog(raw_fil, ch_name=['EOG-left', 'EOG-central', 'EOG-right'])
    ica.exclude.extend([0] + eog_indices)
        
    ica.apply(raw_fil, verbose=log)
    raw_fil.drop_channels(['EOG-left', 'EOG-central', 'EOG-right'])
    print("ICA")
    visualization.plot_raw(raw_fil, duration=3, start=1691.5)
    visualization.plot_psd(raw_fil)

    events, event_id_map = mne.events_from_annotations(raw)

    print("Epochs")
    epochs = mne.Epochs(raw_fil, events, event_id=event_id, tmin=tmin, tmax=tmax,
                        proj=True, baseline=None, preload=True,
                        event_repeated='merge',
                        verbose=log)         
    epochs[1].plot(n_epochs=1, block=True)
    print("Epochs baseline")
    epochs.plot_image(combine='mean')
    epochs.apply_baseline(baseline, verbose=log)
    epochs.plot_image(combine='mean')

    print("Rerefrence")
    re_epochs = epochs.copy().set_eeg_reference('average', projection=True, verbose=log)

    return re_epochs
