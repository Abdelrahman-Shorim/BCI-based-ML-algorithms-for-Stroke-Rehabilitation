def plot_raw(raw,start,duration):
    raw.plot(duration=duration, start=start)

def plot_psd(raw):
    raw.compute_psd().plot()
